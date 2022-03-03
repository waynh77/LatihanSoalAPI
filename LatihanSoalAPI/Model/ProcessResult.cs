
namespace LatihanSoalAPI.Model
{
    public class ProcessResult
    {
        public bool isSucceed
        {
            get;
            set;
        }

        public string message
        {
            get;
            set;
        }

        public void InsertSucceed()
        {
            this.isSucceed = true;
            this.message = "Data has been saved.";
        }

        public void UpdateSucceed()
        {
            this.isSucceed = true;
            this.message = "Data has been saved.";
        }

        public void DeleteSucceed()
        {
            this.isSucceed = true;
            this.message = "Data has been Deleted.";
        }
        public void DeleteFailed()
        {
            this.isSucceed = true;
            this.message = "Data gagal hapus.";
        }
        public void SetException(Exception e)
        {
            this.isSucceed = false;
            this.message = e.GetBaseException().Message;
        }
    }
}
