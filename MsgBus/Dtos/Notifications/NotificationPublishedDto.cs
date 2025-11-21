namespace migApp.Shared.MsgBus.Dtos.Notifications
{
    public class NotificationPublishedDto : NotificationDtoClass
    {
        public override string ReceiverId { get; set; }
        public override string Message { get; set; }
    }
}
