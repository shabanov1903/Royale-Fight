public interface IPlayerSingletone
{
    // ����� ������ Singletone
    // ��������� ��� �������� ���� ������� ���������� ������
    public player player { get; set; }

    // ������� ���� Set ���������� ��� ������ ���������� ��������
    // �������� ������ ������������ ��������������� � ���� ������ �������
    public void SetHero(int var);
    public void SetSkin(int var);
    public void SetLevel(int var);
    public void ChangeExperience(int var);
    public void ChangeCoins(int var);
    public void ChangeCrystals(int var);
}