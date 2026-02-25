using JetBrains.Annotations;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class FollowPlayer : ActionTask {

		public BBParameter<GridTest> grid;
        public BBParameter<GameObject> target;
        public BBParameter<float> timeBeforeMovement = 2;
		public BBParameter<float> currentTime;
        public BBParameter<float> stopDistance;
        public BBParameter<GameObject> thisObject;

        //IN BLOCKS
        public BBParameter<int> height;

        //public BBParameter<float> timeBeforeDropping;
        //public BBParameter<float> maxTimeBeforeDropping;
        //public BBParameter<GameObject> startingGridObject;

        public BBParameter<int> gridCellSize;

		public BBParameter<int> stepDistance;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            stepDistance = stepDistance.value * gridCellSize.value;
            grid.value.snapObjectToGrid(thisObject.value, height.value);
            grid.value.snapToCenterCell(thisObject.value, thisObject.value.transform.position.x);
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
			//set in to follow player
			followPlayer();
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		private int getPlayerYDirection(float distance)
		{
			if (distance > 0)
			{
				return -1;
			}
            if (distance < 0)
            {
                return 1;
            }
			else
			{
				return 0;
			}
        }

		private bool countUpTime(float maxTime)
		{
            currentTime.value += Time.deltaTime;
			//Mathf.Clamp(currentTime.value, 0, maxTime);

            
            if (currentTime.value >= maxTime)
			{
				currentTime.value = 0;
                return true;
			}
			else
			{
				return false;
			}
        }




		private void followPlayer()
		{
            //get Y distance between player and AI enemy
            float YDistance = agent.transform.position.x - target.value.transform.position.x;

            if (countUpTime(timeBeforeMovement.value))
			{
				if (Mathf.Abs (YDistance) >= stopDistance.value)
				{
					
					//follow player logic here

					//get which direction the player is compared to the object, 
					int direction = getPlayerYDirection(YDistance);
					

					//calculate new position 
					Vector2 newPosition = new Vector2(agent.transform.position.x + direction * gridCellSize.value, agent.transform.position.y );

					//apply position 
					agent.transform.position = newPosition;
				}
			}
			else if(YDistance <= stopDistance.value)
			{
				//reached the player, ready to fire
				Debug.Log("reacehd player");
				EndAction(true);
			}
        }
	}
}