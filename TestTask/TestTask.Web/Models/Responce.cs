namespace TestTask.Web.Models
{
    public class Responce<T>
    {
        public T Result { get; set; }
        public Error Error { get; set; }
    }
}
