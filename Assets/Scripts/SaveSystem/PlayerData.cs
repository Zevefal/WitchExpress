[System.Serializable]
public class PlayerData
{
	public int Money;
	public int Energy;
	public int Health;
	public float Mobility;
	public int Speed;
	public float Volume;
	public bool Music;
	public int MobilityLevel;
	public int SpeedLevel;
	public int HealthLevel;
	public bool TutorialEnable;

	public PlayerData()
	{
		Money = 50;
		Energy = 50;
		Health = 10;
		Mobility = 25;
		Speed = 5;
		Volume = 1;
		MobilityLevel = 1;
		SpeedLevel = 1;
		HealthLevel = 1;
		Music = true;
		TutorialEnable = true;
	}
}