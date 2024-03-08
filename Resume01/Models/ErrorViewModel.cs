namespace Resume01.Models
{
    public class ErrorViewModel
    {

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

#nullable enable // ????????????? warning ????????
        public string? RequestId { get; set; }
#nullable disable

    }
}
