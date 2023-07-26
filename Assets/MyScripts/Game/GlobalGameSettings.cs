public static class GlobalGameSettings 
{
	public static float MasterVolume;
	public static Difficulty Difficulty;

	public static int CurrentCoins;
	public static int MaxCoins;
}

[System.Serializable]
public enum Difficulty
{
	Easy,
	Normal,
	Hard
}

[System.Serializable]
public class PlayerData
{
	public float MasterVolume;
	public Difficulty Difficulty;
	public int MaxCoins;
}