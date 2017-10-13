using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vuforia
{
	public class ImageTargetPlayAudio : MonoBehaviour,
										ITrackableEventHandler
	{
		private AudioSource audio;

		private TrackableBehaviour trackableBehaviour;

		void Start ()
		{
			audio = GetComponent<AudioSource> ();

			trackableBehaviour = GetComponent<TrackableBehaviour> ();
			if (trackableBehaviour) {
				trackableBehaviour.RegisterTrackableEventHandler (this);
			}

		}

		public void OnTrackableStateChanged (
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
			   newStatus == TrackableBehaviour.Status.TRACKED ||
			   newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {

				audio.Play ();
			} else {

				audio.Pause ();
			}
		}
	}

}