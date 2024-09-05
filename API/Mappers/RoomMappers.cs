using API.DTOs;
using DomainModels;
using System.Runtime.CompilerServices;

namespace API.Mappers
{
    // here we use a mapper. a mapper is a class that is used to map one object to another.
    public static class RoomMappers
    {
        //Here we have a method that maps a GetRoomDetailsDTO to a Room object in the Domain Models folder
        public static Room toGetRoomDetails(this GetRoomDetailsDTO roomDTO) 
        {
            return new Room
            {
                Rooms = roomDTO.Rooms,
                RoomNumber = roomDTO.RoomNumber,
                Beds = roomDTO.Beds,
                Price = roomDTO.Price,
                Status = roomDTO.Status,
                Condition = roomDTO.Condition
            };
        }
    }
}
