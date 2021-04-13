using System.Collections.Generic;
using System.Drawing;
using System;
using System.Linq;
using System.Text;

namespace TestGame
{
    class World
    {
        public static World Instance { get; private set; }

        private List<GameObject> GameObjects {get; set;}

        private List<GameObject> m_AddedGameObjects;
        private List<GameObject> m_RemovedGameObjects;

        private List<GameEvent> GameEvents { get; set; }
        public int WorldTime { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public Color BackColor { get; set; }
 
        private World()
        {
            GameObjects = new List<GameObject>();

            m_AddedGameObjects = new List<GameObject>();
            m_RemovedGameObjects = new List<GameObject>();

            GameEvents = new List<GameEvent>();

            BackColor = Color.Black;
        }

        static World()
        {
            Instance = new World();
        }
    
        internal void Paint(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(BackColor), 0, 0, graphics.ClipBounds.Width, graphics.ClipBounds.Height);

 	        foreach (GameObject gameObjects in GameObjects)
	        {
                gameObjects.Paint(graphics);
            }
        }

        public void DoTime(int time)
        {
            WorldTime += time;
            ExecuteGameEvents();

            foreach (GameObject gameObject in GameObjects)
            {
                gameObject.DoTime();
            }

            AddAndRemoveObjects();
        }

        internal void AddObject(GameObject gameObject)
        {
            gameObject.World = this;
            m_AddedGameObjects.Add(gameObject);            
        }

        internal void RemoveObject(GameObject gameObject)
        {         
            GameObjects.Remove(gameObject);
        }

        void AddAndRemoveObjects()
        {
            foreach (GameObject gameObject in m_AddedGameObjects)
            {
                GameObjects.Add(gameObject);
            }

            foreach (GameObject gameObject in m_RemovedGameObjects)
            {
                GameObjects.Remove(gameObject);
            }

            m_AddedGameObjects.Clear();
            m_RemovedGameObjects.Clear();
        }

        internal void AddEvent(GameEvent newGameEvent, int timeToEvent)
        {
            if (newGameEvent.EventTime == 0)
            {
                newGameEvent.EventTime = WorldTime + timeToEvent;
            }

            int insertIndex = 0;
            for (int index = GameEvents.Count - 1; index >= 0 ; index--)
            {
                GameEvent nextGameEvent = GameEvents[index];
                if (nextGameEvent.EventTime <= newGameEvent.EventTime)
                {
                    insertIndex = index + 1;
                    break;
                }
            }

            GameEvents.Insert(insertIndex, newGameEvent);
            return;
  
        }

        void ExecuteGameEvents()
        {            
            while (GameEvents.Count > 0 && GameEvents[0].EventTime <= WorldTime)
            {    
                GameEvent gameEvent = GameEvents[0];
                gameEvent.ExecuteEvent();
                GameEvents.RemoveAt(0);
            }
        }
    }
}
