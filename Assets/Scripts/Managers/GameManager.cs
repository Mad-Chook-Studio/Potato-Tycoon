using System.Linq;
using Buildings;
using Seasons;
using UnityEngine;
using Workers;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
    
        public CurrencyManager CurrencyManager { get; private set; }
        public BuildingManager BuildingManager { get; private set; }
        public WorkerManager WorkerManager { get; private set; }
        public PotatoManager PotatoManager { get; private set; }
        public QuestManager QuestManager { get; private set; }
        public SeasonManager SeasonManager { get; private set; }

        [SerializeField]
        private float _baseGrowthRate = 1f;

        [SerializeField] 
        private float _tickTime = 1.0f;
    
        private float _timer = 0f;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            CurrencyManager = new CurrencyManager();
            BuildingManager = new BuildingManager(FindObjectsOfType<BuildingPlot>().ToList());
            WorkerManager = new WorkerManager();
            PotatoManager = new PotatoManager(_baseGrowthRate, Resources.LoadAll<Potato>("").ToList());
            QuestManager = new QuestManager();
            SeasonManager = new SeasonManager();
        }
    
        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer < _tickTime) return;
        
            GrowPotatoes();
            _timer = 0f;
        }

        private void GrowPotatoes()
        {
            foreach (Field field in PotatoManager.Fields)
            {
                float efficiency = (field.PlantedPotato.Level);
                field.GrowPotato(_baseGrowthRate * efficiency);
            }
        }

        private float CalculateTotalEfficiency(int levelRequired)
        {
            float totalEfficiency = WorkerManager.Workers
                .Where(worker => worker.Level >= levelRequired)
                .Sum(worker => worker.EfficiencyMultiplier);

            return 1 + totalEfficiency;
        }
    }
}