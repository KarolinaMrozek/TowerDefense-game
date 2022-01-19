using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint StandardTurret;
    public TurretBlueprint AnotherTurret;
    public TurretBlueprint TheBestTurret;


    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(StandardTurret);
    }

    public void SelectAnotherTurret()
    {
        Debug.Log("Another Turret Selected");
        buildManager.SelectTurretToBuild(AnotherTurret);
    }

    public void SelectTheBestTurret()
    {
        Debug.Log("The Best Turret Selected");
        buildManager.SelectTurretToBuild(TheBestTurret);
    }

}
