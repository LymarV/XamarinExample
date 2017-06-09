using Prism.Events;

namespace XamarinExample.Messages
{
	public struct UploadProgressData
	{
		public int AudioId { get; set; }
		public int Step { get; set; }
		public int Total { get; set; }

		public UploadProgressData (int audioId, int step, int totalSteps)
		{
			AudioId = audioId;
			Step = step;
			Total = totalSteps;
		}
	}

	public class UploadProgressMessage: PubSubEvent<UploadProgressData>
	{

	}
}
