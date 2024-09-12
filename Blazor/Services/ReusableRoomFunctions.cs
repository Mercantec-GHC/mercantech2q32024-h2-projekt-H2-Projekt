using DomainModels;


namespace Blazor.Services
{
    public class ReusableRoomFunctions
    {
        bool roomFree;
        private readonly DatabaseServices DBServices = new DatabaseServices(new HttpClient());
        //this function makes a call to a DB services method to get all rooms,
        //then it goes through all the rooms until it finds one that is free for the booking dates,
        //finally it saves all booking dates to a new rooms booked days list for use later
        public async Task<int> GetRoom(string roomType, CreateBookingDTO booking, Room room)
        {
            List<Room> rooms = await DBServices.GetAllRooms();
            foreach (Room potentialRoom in rooms)
            {
                if (potentialRoom.Type == roomType)
                {
                    roomFree = true;
                    DateTime tempDate = booking.StartDate;
                    while (tempDate.Date < booking.EndDate.Date)
                    {
                        foreach (DateTime bookedDate in potentialRoom.BookedDays)
                        {
                            if (bookedDate.Date == tempDate.Date)
                            {
                                roomFree = false;
                                break;
                            }
                        }
                        if (!roomFree)
                        {
                            break;
                        }
                        room.BookedDays.Add(DateTime.SpecifyKind(tempDate, DateTimeKind.Utc));

                        tempDate = tempDate.AddDays(1);
                    }
                    if (roomFree)
                    {
                        foreach (DateTime date in potentialRoom.BookedDays)
                        {
                            room.BookedDays.Add(DateTime.SpecifyKind(date, DateTimeKind.Utc));
                        }

                        return potentialRoom.RoomId;
                    }
                }
            }
            return 0;
        }
    }
}
