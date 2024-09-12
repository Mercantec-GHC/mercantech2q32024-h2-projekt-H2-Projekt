namespace DomainModels.DB
{
    public class PremiumHouse : RoomType
    {
        public PremiumHouse()
        {
            PricePerNight = CalRoomPrice(this);
            RoomTypeName = "PremiumHouse";
            Tags = new List<string>()
            {
                "Dobbeltseng", "badeværelse med badekar og bruser", "TV", "skrivebord", "minibar", "Wi-Fi", "balkon"
            };
        }

        public string numberOfRooms { get; set; }
        public decimal CalRoomPrice(PremiumHouse rooms)
        {
            if (rooms.numberOfRooms == "single room")
            {
                return 900;
            }
            else if (rooms.numberOfRooms == "double room")
            {
                return 1200;
            }
            else
            {
                return 0;
            }
        }
    }


}
