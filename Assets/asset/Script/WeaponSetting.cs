//������ ������ ���� ������ �� �������� ����ϴ� �������� ����ü�� ��� �����ϸ�
// ������ �߰�/������ �� ����ü�� �����ϱ� ������ �߰�/������ ���� ������ ������

public enum WeaponName { AssaultRifle = 0}

[System.Serializable] 
public struct WeaponSetting
{
    public WeaponName weaponName; //���� �̸�
    public int currentMagazine; //���� źâ ��
    public int maxMagazine; //�ִ� źâ ��
    public int currentAmmo; //���� ź�� ��
    public int maxAmmo; //�ִ� ź���
    public float attackRate; //���� �ӵ�
    public float attackDistance; //���� ��Ÿ�
    public bool isAutomaticAttack; // ���� ���� ����
}