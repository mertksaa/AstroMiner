using UnityEngine;
using UnityEngine.AI;

public class DroneAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Driller targetDriller;
    public TradeCenter tradeCenter;

    public int capacity = 3;       
    public int currentPayload = 0; 

    private enum DroneState { GoingToDriller, GoingToTradeCenter }
    private DroneState currentState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = DroneState.GoingToDriller;
        // Start içindeki ilk hareket emrini sildik, onu Update içine alacağız
    }

void Update()
    {
        // YZ aktif değilse veya zemine henüz tutunamadıysa bekle
        if (!agent.isActiveAndEnabled || !agent.isOnNavMesh) return;

        capacity = DroneManager.Instance.globalCapacity;
        agent.speed = DroneManager.Instance.globalSpeed;
        
        // DRONE KAYBOLMAMASI İÇİN: Eğer bir rotası yoksa, rotayı zorla çiz
        if (!agent.hasPath) 
        {
            Transform currentTarget = (currentState == DroneState.GoingToDriller) ? targetDriller.transform : tradeCenter.transform;
            agent.SetDestination(currentTarget.position);
        }

        // Hedefe ulaştık mı?
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (currentState == DroneState.GoingToDriller)
            {
                if (targetDriller.currentOre > 0)
                {
                    currentPayload = targetDriller.TakeOre(capacity);
                    currentState = DroneState.GoingToTradeCenter;
                    agent.SetDestination(tradeCenter.transform.position);
                }
            }
            else if (currentState == DroneState.GoingToTradeCenter)
            {
                if (currentPayload > 0)
                {
                    tradeCenter.SellOre(currentPayload);
                    currentPayload = 0;
                }
                currentState = DroneState.GoingToDriller;
                agent.SetDestination(targetDriller.transform.position);
            }
        }
    }
    }
