using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	
    public class countUpTimer : ActionTask {

		public BBParameter<float> runTime;
		public BBParameter<float> cooldownTime;
		public BBParameter<bool> readyToFire;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Timer();

        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		private void Timer()
		{
			
			runTime.value += Time.deltaTime;
			if (runTime.value >= cooldownTime.value)
			{
				runTime.value = 0;
				readyToFire.value = true;
            }
			else
			{
				readyToFire.value = false;
			}
		}
	}
}