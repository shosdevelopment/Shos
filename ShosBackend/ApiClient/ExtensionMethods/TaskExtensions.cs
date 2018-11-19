using System.Threading.Tasks;

namespace ApiClient.ExtensionMethods
{
	internal static class TaskExtensions
	{
		public static T WaitAndGetResult<T>(this Task<T> task)
		{
			task.Wait();
			return task.Result;
		}
	}
}
