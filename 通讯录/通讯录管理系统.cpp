#include <iostream>
using namespace std;

#define MAX 1000 

struct Person {
	string m_Name;// 姓名
	int m_Sex; // 性别
	int m_Age; // 年龄
	int m_Phone; // 电话
	int m_Addr; // 家庭住址

};
struct Addressbooks {
	struct Person personArray[MAX];
	int m_Size;
};
void showMenu() {
	cout << "********************************" << endl;
	cout << "***** 1、添加联系人      *******" << endl;
	cout << "***** 2、显示联系人      *******" << endl;
	cout << "***** 3、删除联系人      *******" << endl;
	cout << "***** 4、查找联系人      *******" << endl;
	cout << "***** 5、修改联系人      *******" << endl;
	cout << "***** 6、清空联系人      *******" << endl;
	cout << "***** 0、退出通讯录      *******" << endl;
	cout << "********************************" << endl;

}
void addPerson(Addressbooks* _abs) {
	struct Person person;
	cout << "请输入姓名" << endl;
	cin >> person.m_Name;
	cout << "请输入性别 1：男，2：女" << endl;
	cin >> person.m_Sex;
	cout << "请输入年龄" << endl;
	cin >> person.m_Age;
	cout << "请输入手机号" << endl;
	cin >> person.m_Phone;
	cout << "请输入家庭住址" << endl;
	cin >> person.m_Addr;

	_abs->personArray[_abs->m_Size] = person;
	_abs->m_Size++;
	cout << "成功" << endl;
	system("pause");
	system("cls");// 清屏
}
void showPerson(Addressbooks* _abs) {
	if (_abs->m_Size == 0)
	{
		cout << "没有数据了" << endl;
		return;
	}
	for (int i = 0; i < _abs->m_Size; i++)
	{
		cout << "姓名：" << _abs->personArray[i].m_Name << ",Phone:" << _abs->personArray[i].m_Phone << endl;

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
	cout << "请输入要删除的人：" << endl;
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
		cout << "查无此人" << endl;
	}
}
int main()
{

	int select = 0;
	// 创建通讯录结构体变量
	struct Addressbooks abs;
	// 初始化通讯录中当前人员个数
	abs.m_Size = 0;


	while (true)
	{



		showMenu();

		cin >> select;
		switch (select)
		{
		case 1: //1、添加联系人 
			addPerson(&abs);

			break;
		case 2:// 2、显示联系人
			showPerson(&abs);
			cout << "显示成功" << endl;
			system("pause");
			break;
		case 3: //3、删除联系人   
		{
			delPerson(&abs);
		}
		break;
		case 4: // 4、查找联系人   
			break;
		case 5:// 5、修改联系人
			break;
		case 6://6、清空联系人 
			break;
		case 0: // 0、退出通讯录   
			cout << "欢迎下次使用" << endl;
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