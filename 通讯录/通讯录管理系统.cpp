#include <iostream>
using namespace std;

#define MAX 1000 

struct Person {
	string m_Name;// ����
	int m_Sex; // �Ա�
	int m_Age; // ����
	int m_Phone; // �绰
	int m_Addr; // ��ͥסַ

};
struct Addressbooks {
	struct Person personArray[MAX];
	int m_Size;
};
void showMenu() {
	cout << "********************************" << endl;
	cout << "***** 1�������ϵ��      *******" << endl;
	cout << "***** 2����ʾ��ϵ��      *******" << endl;
	cout << "***** 3��ɾ����ϵ��      *******" << endl;
	cout << "***** 4��������ϵ��      *******" << endl;
	cout << "***** 5���޸���ϵ��      *******" << endl;
	cout << "***** 6�������ϵ��      *******" << endl;
	cout << "***** 0���˳�ͨѶ¼      *******" << endl;
	cout << "********************************" << endl;

}
void addPerson(Addressbooks* _abs) {
	struct Person person;
	cout << "����������" << endl;
	cin >> person.m_Name;
	cout << "�������Ա� 1���У�2��Ů" << endl;
	cin >> person.m_Sex;
	cout << "����������" << endl;
	cin >> person.m_Age;
	cout << "�������ֻ���" << endl;
	cin >> person.m_Phone;
	cout << "�������ͥסַ" << endl;
	cin >> person.m_Addr;

	_abs->personArray[_abs->m_Size] = person;
	_abs->m_Size++;
	cout << "�ɹ�" << endl;
	system("pause");
	system("cls");// ����
}
void showPerson(Addressbooks* _abs) {
	if (_abs->m_Size == 0)
	{
		cout << "û��������" << endl;
		return;
	}
	for (int i = 0; i < _abs->m_Size; i++)
	{
		cout << "������" << _abs->personArray[i].m_Name << ",Phone:" << _abs->personArray[i].m_Phone << endl;

	}
}
int isExist(Addressbooks* _abs, string name) {
	for (int i = 0; i < _abs->m_Size; i++)
	{
		if (_abs->personArray[i].m_Name == name)
		{

			return i;
		}

	}
	return -1;
}
void delPerson(Addressbooks* _abs) {
	cout << "������Ҫɾ�����ˣ�" << endl;
	string name;
	cin >> name;
	int index = isExist(_abs, name);
	if (index != -1)
	{
		while (index < _abs->m_Size)
		{
			_abs->personArray[index] = _abs->personArray[index + 1];
			index++;
		}
		_abs->m_Size--;
	}
	else {
		cout << "���޴���" << endl;
	}
}
int main()
{

	int select = 0;
	// ����ͨѶ¼�ṹ�����
	struct Addressbooks abs;
	// ��ʼ��ͨѶ¼�е�ǰ��Ա����
	abs.m_Size = 0;


	while (true)
	{



		showMenu();

		cin >> select;
		switch (select)
		{
		case 1: //1�������ϵ�� 
			addPerson(&abs);

			break;
		case 2:// 2����ʾ��ϵ��
			showPerson(&abs);
			cout << "��ʾ�ɹ�" << endl;
			system("pause");
			break;
		case 3: //3��ɾ����ϵ��   
		{
			delPerson(&abs);
		}
		break;
		case 4: // 4��������ϵ��   
			break;
		case 5:// 5���޸���ϵ��
			break;
		case 6://6�������ϵ�� 
			break;
		case 0: // 0���˳�ͨѶ¼   
			cout << "��ӭ�´�ʹ��" << endl;
			system("pause");
			return 0;
			break;
		default:
			break;
		}
	}
	system("pause");
	return 0;
}