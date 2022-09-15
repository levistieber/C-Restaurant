using Microsoft.EntityFrameworkCore;
using Restaurant.DbContexts;
using Restaurant.DTOs;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.ReservationConflictValidators
{
    public class DatabaseReservationConflictValidator : IReservationConflictValidator
    {
        private readonly RestaurantDbContextFactory _dbContextFactory;

        public DatabaseReservationConflictValidator(RestaurantDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Reservation> GetConflictingReservation(Reservation reservation)
        {
            using (RestaurantDbContext context = _dbContextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = await context.Reservations
                    .Where(r => r.FloorNumber == reservation.TableID.FloorNumber)
                    .Where(r => r.TableNumber == reservation.TableID.TableNumber)
                    .FirstOrDefaultAsync();

                if (reservationDTO == null)
                {
                    return null;
                }    

                return ToReservation(reservationDTO);
            }
        }

        private static Reservation ToReservation(ReservationDTO dto)
        {
            return new Reservation(new TableID(dto.FloorNumber, dto.TableNumber), dto.Name, dto.ResTime);
        }
    }
}
