using FoonkieInterview.Common.Contracts.Providers;
using FoonkieInterview.Models;
using FoonkieInterview.Repository.Contracts.Repositories;
using FoonkieInterview.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FoonkieInterview.ViewModels
{
    public class StartupViewModel : BaseViewModel
    {
        private readonly IEmailProvider _emailProvider;
        private readonly ILaboratoryRepository _laboratoryRepository;
        private readonly ICaseStudyRepository _caseStudyRepository;

        private CarouselView _carouselView;

        private Laboratory _laboratory;
        private List<CaseStudy> _allCaseStudies;
        private int _currentCaseIndex;

        public ObservableCollection<CaseStudy> CaseStudies { get; }
        public ObservableCollection<Laboratory> Laboratories { get; }

        public Laboratory SelectedLaboratory
        {
            get => _laboratory;
            set
            {
                SetProperty(ref _laboratory, value);
                UpdateCaseStudies();
            }
        }

        public ICommand GetInTouchCommand { get; }
        public ICommand ShowUsersCommand { get; }
        public ICommand PreviousCaseStudyCommand { get; }
        public ICommand NextCaseStudyCommand { get; }

        public StartupViewModel(CarouselView carouselView = null)
        {
            _carouselView = carouselView;
            Laboratories = new ObservableCollection<Laboratory>();
            CaseStudies = new ObservableCollection<CaseStudy>();

            _emailProvider = DependencyService.Get<IEmailProvider>();
            _laboratoryRepository = DependencyService.Get<ILaboratoryRepository>();
            _caseStudyRepository = DependencyService.Get<ICaseStudyRepository>();

            _allCaseStudies = new List<CaseStudy>();

            GetInTouchCommand = new Command(async () => await PerformGetInTouch());
            PreviousCaseStudyCommand = new Command(() => PreviousCaseStudy());
            NextCaseStudyCommand = new Command(() => NextCaseStudy());
            ShowUsersCommand = new Command(async () => await Shell.Current.GoToAsync($"{nameof(UsersPage)}"));
        }

        private void NextCaseStudy()
        {
            if (!CaseStudies.Any())
                return;

            _currentCaseIndex = _currentCaseIndex < CaseStudies.Count - 1 ? _currentCaseIndex + 1 : 0;
            _carouselView.Position = _currentCaseIndex;
        }

        private void PreviousCaseStudy()
        {
            if (!CaseStudies.Any())
                return;

            _currentCaseIndex = _currentCaseIndex > 0 ? --_currentCaseIndex : CaseStudies.Count - 1;
            _carouselView.Position = _currentCaseIndex;
        }

        public async void OnAppearing()
        {
            IsBusy = true;

            await LoadData();
        }

        private async Task LoadData()
        {
            IsBusy = true;

            try
            {
                Laboratories.Clear();
                CaseStudies.Clear();
                _allCaseStudies.Clear();

                var laboratoryResponse = await _laboratoryRepository.GetLaboratoriesAsync();
                foreach (var laboratory in laboratoryResponse)
                    Laboratories.Add(Mapper.Map<Laboratory>(laboratory));

                var caseStudyResponse = await _caseStudyRepository.GetCaseStudiesAsync();
                foreach (var caseStudy in caseStudyResponse)
                    _allCaseStudies.Add(Mapper.Map<CaseStudy>(caseStudy));

                SelectedLaboratory = Laboratories.FirstOrDefault();
                _currentCaseIndex = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task PerformGetInTouch()
        {
            var subject = "I want a quote";
            var body = "I need you to build an application";

            await _emailProvider.SendEmail(subject, body);
        }

        private void UpdateCaseStudies()
        {
            CaseStudies.Clear();

            if (SelectedLaboratory != null && (_allCaseStudies?.Any() ?? false))
                foreach (var caseStudy in _allCaseStudies.Where(x => x.LaboratoryId == SelectedLaboratory.Id))
                    CaseStudies.Add(caseStudy);

            _currentCaseIndex = 0;
        }
    }
}
