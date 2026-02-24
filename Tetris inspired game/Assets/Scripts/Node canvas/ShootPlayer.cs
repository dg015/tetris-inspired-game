using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ShootPlayer : ActionTask {

		public BBParameter<List<GameObject>> blocks;
		public BBParameter<GameObject> fireLocation;


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			shoot();
        }

		private void shoot()
		{
			GameObject.Instantiate(chooseBlock(blocks.value), fireLocation.value.transform.position,Quaternion.identity);
			EndAction(true);
		}

		private GameObject chooseBlock(List<GameObject> listOfBlocks)
		{
			return listOfBlocks[Random.Range(0, listOfBlocks.Count)];
		}


		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}