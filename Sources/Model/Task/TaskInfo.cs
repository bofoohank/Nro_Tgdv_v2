namespace NRO_Server.Model.Task
{
    public class TaskInfo
    {
       public short Id { get; set; } 
       public sbyte Index { get; set; }     
       public short Count { get; set; }

       public TaskInfo()
       {
           Id = 21; // 0 là làm từ đầu // 31 là max từ source
           Index = 0;
           Count = 0;
       }
    }
}