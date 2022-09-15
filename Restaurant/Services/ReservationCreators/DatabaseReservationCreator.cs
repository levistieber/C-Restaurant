using Restaurant.DbContexts;
using Restaurant.DTOs;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.ReservationCreators
{
    public class DatabaseReservationCreator : IReservationCreator
    {
        private readonly RestaurantDbContextFactory _dbContextFactory;

        public DatabaseReservationCreator(RestaurantDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateReservation(Reservation reservation)
        {
            using (RestaurantDbContext context = _dbContextFactory.CreateDbContext())
            {
                await Task.Delay(3000);

                ReservationDTO reservationDTO = ToReservationDTO(reservation);

                context.Reservations.Add(reservationDTO);
                await context.SaveChangesAsync();
            }
        }

        private ReservationDTO ToReservationDTO(Reservation reservation)
        {
            return new ReservationDTO()
            {
                FloorNumber = reservation.TableID?.FloorNumber ?? 0,
                TableNumber = reservation.TableID?.TableNumber ?? 0,
                Name = reservation.Name,
                ResTime = reservation.ResTime,
            };
        }
    }
}
