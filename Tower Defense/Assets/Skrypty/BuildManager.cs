using UnityEngine.EventSystems;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Nie da sie tutaj");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;
    public GameObject thebestTurretPrefab;

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStat.Money >= turretToBuild.cost; } }

    public void BuildTurretOn (Node node)
    {
        if (PlayerStat.Money < turretToBuild.cost)
        {
            Debug.Log("Niewystarczająca ilość monet!");
            return; 
        }

        PlayerStat.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);


        Debug.Log("Wieżyczka zbudowana! Ilość straconych monet: " + PlayerStat.Money);

    }
    //opcje przycisku sprzedawania
    public void SelectNode(Node node)
    {

        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
   

}
