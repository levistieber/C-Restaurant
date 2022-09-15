using Restaurant.Exceptions;
using Restaurant.Models;
using Restaurant.Services;
using Restaurant.Stores;
using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Restaurant.Commands
{
    public class MakeReservationCommand : AsyncCommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly HotelStore _hotelStore;
        private readonly NavigationService<ReservationListingViewModel> _reservationViewNavigationService;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, 
            HotelStore hotelStore,
            NavigationService<ReservationListingViewModel> reservationViewNavigationService)
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotelStore = hotelStore;
            _reservationViewNavigationService = reservationViewNavigationService;
            
            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _makeReservationViewModel.CanCreateReservation && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _makeReservationViewModel.SubmitErrorMessage = string.Empty;
            _makeReservationViewModel.IsSubmitting = true;

            Reservation reservation = new Reservation(
                new TableID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.TableNumber),
                _makeReservationViewModel.Name,
                _makeReservationViewModel.ResDate);

            try
            {
                await _hotelStore.MakeReservation(reservation);

                MessageBox.Show("Successfully reserved table.", "Success!",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                _reservationViewNavigationService.Navigate();
            }
            catch (ReservationConflictException)
            {
                _makeReservationViewModel.SubmitErrorMessage = "This table is already taken on that date.";
            }
            catch (Exception)
            {
                _makeReservationViewModel.SubmitErrorMessage = "Failed to make reservation.";
            }

            _makeReservationViewModel.IsSubmitting = false;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MakeReservationViewModel.CanCreateReservation))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
