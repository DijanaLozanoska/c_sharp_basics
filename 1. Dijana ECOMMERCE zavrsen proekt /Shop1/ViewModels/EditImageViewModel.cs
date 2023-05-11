namespace Shop1.ViewModels
{
    public class EditImageViewModel : UploadImageViewModel
    {
        public int Id { get; set; }
        public string ExistingImage { get; set; }
        public string ExistingImageBack { get; set; }
    }
}
