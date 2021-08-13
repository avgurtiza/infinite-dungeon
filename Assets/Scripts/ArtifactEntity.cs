[System.Serializable]

public class ArtifactEntity 
{
    public string name;
    public string shortName;
    public float weight;
    public float attackModifier;
    public float defenseModifier;
    private bool isActive = false;


    public ArtifactEntity(string name, string shortName, bool isActive, float weight, float attackModifier, float defenseModifier) {
    	this.name = name;
    	this.shortName = shortName;
    	this.weight = weight;
    	this.attackModifier = attackModifier;
    	this.defenseModifier = defenseModifier;
        this.isActive = isActive;
    }

    public ArtifactEntity(string name, string shortName, bool isActive, float weight) {
        this.name = name;
        this.shortName = shortName;
        this.weight = weight;
        this.isActive = isActive;
    }

    public ArtifactEntity(string name, string shortName, bool isActive) {
        this.name = name;
        this.shortName = shortName;
        this.isActive = isActive;
    }

    public bool IsActive() {
    	return isActive;
    }

    public void Activate() {
    	isActive = true;
    }

    public void Deactivate() {
    	isActive = false;
    }
}
