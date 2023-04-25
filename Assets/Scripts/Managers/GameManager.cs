using System.Linq;
using Buildings;
using Fields;
using Quests;
using Seasons;
using UnityEngine;
using Workers;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
    
        public static CurrencyManager CurrencyManager;
        public static QuestManager QuestManager;
        
        public static BuildingManager BuildingManager;
        public static WorkerManager WorkerManager;
        
        public static SeasonManager SeasonManager;
        public static PotatoManager PotatoManager;
        public static FieldManager FieldManager;
        

        [SerializeField]
        private float _baseGrowthRate = 1f;

        public static float BaseGrowthRate;

        [SerializeField] 
        private float _tickTime = 1.0f;
    
        private float _timer;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            BaseGrowthRate = _baseGrowthRate;

            CurrencyManager = new CurrencyManager();
            BuildingManager = new BuildingManager(FindObjectsOfType<BuildingPlot>().ToList());
            WorkerManager = new WorkerManager();
            PotatoManager = new PotatoManager();
            QuestManager = new QuestManager();
            SeasonManager = new SeasonManager();
            FieldManager = new FieldManager(FindObjectsOfType<Field>().ToList());
        }
    
        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer < _tickTime) return;
        
            FieldManager.GrowPotatoes();
            _timer = 0f;
        }

        public static float CalculateTotalEfficiency(int potatoLevel)
        {
            float totalEfficiency = WorkerManager.GetWorkerEfficiency(potatoLevel);
            return 1 + totalEfficiency;
        }
    }
}