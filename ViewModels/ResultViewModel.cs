namespace BlockCountries.ViewModels
{
    public class ResultViewModel<T>
    {

     public   T data { get; set; }
       public bool success {  get; set; }


        public static ResultViewModel<T> Success(T Data)
        {
            return new ResultViewModel<T>() { data= Data
            , success = true
            };  
        }
        public static ResultViewModel<T> Failure(T viewmodel)
        {
            return new ResultViewModel<T>
            {
                
            
                success = false
            };
        }
    }
}
