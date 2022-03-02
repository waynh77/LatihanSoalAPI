
namespace LatihanSoalAPI.Model
{
    public class ProcessResultT<T> : ProcessResult
    {
        public ProcessResultT()
        {
        }

        public T returnValue
        {
            get;
            set;
        }

        public void SetReturnValue(T value)
        {
            isSucceed = true;
            returnValue = value;
        }
    }
}
