using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class AudioClipSerializer
{
	//Load AudioClip from a local binary file and set it to audioSource
	public static void LoadAudioClipFromDisk(AudioSource audioSource, string filename)
	{
		if (File.Exists (Application.persistentDataPath + "/"+ filename)) {

			//deserialize local binary file to AudioClipSample
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/" + filename, FileMode.Open);
			AudioClipSample clipSample = (AudioClipSample) bf.Deserialize (file);
			file.Close ();

			//create new AudioClip instance, and set the (name, samples, channels, frequency, [stream] play immediately without fully loaded)
			AudioClip newClip = AudioClip.Create(filename, clipSample.samples, clipSample.channels, clipSample.frequency, false);

			//set the acutal audio sample to the AudioClip (sample, offset)
			newClip.SetData (clipSample.sample, 0);

			//set to the AudioSource
			audioSource.clip = newClip;
		}
		else
		{
			Debug.Log("File Not Found!");
		}
	}

	public static void SaveAudioClipToDisk(AudioClip audioClip, string filename)
	{
		//create file
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath+ "/" + filename);

		//serialize by setting the sample, frequency, samples, and channels to the new AudioClipSample instance
		AudioClipSample newSample = new AudioClipSample();
		newSample.sample = new float[audioClip.samples * audioClip.channels];
		newSample.frequency = audioClip.frequency;
		newSample.samples = audioClip.samples;
		newSample.channels = audioClip.channels;

		//get the actual sample from the AudioClip
		audioClip.GetData (newSample.sample, 0);


		bf.Serialize (file, newSample);
		file.Close ();
	}

	[Serializable]
	class AudioClipSample
	{
		public int frequency;
		public int samples;
		public int channels;
		public float[] sample;
	}
}