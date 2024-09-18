namespace DomainModels.DB
{
    public class PremiumHouse : RoomType
    {
        public PremiumHouse()
        {
            PricePerNight = CalRoomPrice();
            RoomTypeName = "PremiumHouse";
            Tags = new List<string>()
            {
                "Dobbeltseng", "badeværelse med badekar og bruser", "TV", "skrivebord", "minibar", "Wi-Fi", "balkon"
            };
        }

        public string numberOfRooms { get; set; }
        public decimal CalRoomPrice()
        {
            if (numberOfRooms == "single room")
            {
                return 900;
            }
            else if (numberOfRooms == "double room")
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
