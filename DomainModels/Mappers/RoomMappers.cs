using DomainModels.DB;
using DomainModels.DTO;
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
                Beds = roomDTO.Beds,
                Price = roomDTO.Price,
                Condition = roomDTO.Condition
            };
        }
    }
}
