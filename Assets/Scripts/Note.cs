using UnityEngine;

namespace PixelatedLabs.UnityNotes
{
	[AddComponentMenu("Miscellaneous/Note")]
	public class Note : MonoBehaviour
	{
		[SerializeField]
		string content = "Click here to edit your note.";

		public string Content
		{
			get { return content; }
			set { content = value; }
		}
	}
}