namespace AsyncDemo;

public class MijnService
{
	public Task GeefData()
	{
		return Http.GetAsync();
	}
}