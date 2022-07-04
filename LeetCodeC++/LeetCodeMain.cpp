#include <iostream>
using namespace std;
#include <vector>


struct TreeNode {
	int val;
	TreeNode* left;
	TreeNode* right;
	TreeNode() : val(0), left(nullptr), right(nullptr) {}
	TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
	TreeNode(int x, TreeNode* left, TreeNode* right) : val(x), left(left), right(right) {}
};

class Solution {
public:
	TreeNode* deleteNode(TreeNode* root, int key)
	{
		if (root == nullptr) return nullptr;
		if (key > root->val) // Ŀ��ڵ���ڵ�ǰ�ڵ�ֵ��ȥ����������ɾ
		{
			root->right = deleteNode(root->right, key);
		}
		else if (key < root->val)// Ŀ��ڵ�С�ڵ�ǰֵ��ȥ����������ɾ
		{
			root->left = deleteNode(root->left, key);
		}
		else // �ҵ�ֵ��
		{
			if (!root->left)// ���û��������
			{
				return root->right; // ��������������λ��
			}
			if (!root->right) // û��������
			{
				return root->left; // ��������������λ��
			}
			TreeNode* node = root->right;
			// ���ҽڵ㶼�� 
			while (node->left)
			{
				node = node->left;
			}
			node->left = root->left; // ������ת�Ƶ� ������������ڵ���������ϣ�Ȼ����������������λ��
			root = root->right;
		}
		return root;
	}
	/// <summary>
	/// ż����ǰ��
	/// </summary>
	/// <param name="nums"></param>
	/// <returns></returns>
	vector<int> sortArrayByParity(vector<int>& nums)
	{
		int index = 0;
		int i = 0;
		while (i < nums.size() - index)
		{
			if (nums[i] % 2 != 0)// �����ǰ����� ���������ͺ����һ��������
			{
				int temp = nums[nums.size() - 1 - index];
				nums[nums.size() - 1 - index] = nums[i];
				nums[i] = temp;
				index++;
				continue;
			}
			i++;
		}
		return nums;
	}
	/// <summary>
	/// ����֮��
	/// </summary>
	/// <param name="nums"></param>
	/// <returns></returns>
	vector<vector<int>> threeSum(vector<int>& nums) {

	}
	/// <summary>
	/// ���ص�����һ��������
	/// </summary>
	/// <param name="v"></param>
	/// <param name="k">����</param>
	/// <returns></returns>
	int findNextStartIndex(vector<int>& v, int k) {

	}
	/// <summary>
	/// 1823. �ҳ���Ϸ�Ļ�ʤ��
	/// </summary>
	/// <param name="n"></param>
	/// <param name="k"></param>
	/// <returns></returns>

	int findTheWinner(int n, int k)
	{
		// Լɪ��
		vector<int> v;
		int count = n;
		int startIndex = 0;
		for (int i = 1; i <= n; i++)
		{
			v.push_back(i);
		}

		findNextStartIndex(v, k);


		return 0;
	}
	/// <summary>
	/// ������ִ�
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>

	string longestPalindrome(string s) {
		/*	���룺s = "babad"
			�����"bab"
			���ͣ�"aba" ͬ���Ƿ�������Ĵ𰸡�*/
		int low = 0;
		int fast = s.length() - 1;

		int startIndex = 0;
		int endIndex = fast;


		while (low < fast)
		{
			if (s[startIndex] == s[endIndex])
			{
				startIndex++;
				endIndex--;
				if (endIndex > startIndex)
				{

				}
			}
		}

	}
	/// <summary>
	/// 647.�����ִ�
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	int countSubstrings(string s) {

	}

	string longestCommonPrefix(vector<string>& strs) {
		int len = 0;
		while (len < strs[0].size())
		{
			for (int i = 0; i < strs.size() - 1; i++)
			{
				if (strs[i].size() <= len || strs[i + 1].size() <= len)
				{
					// Console.WriteLine("���Ȳ���������");
					return strs[0].substr(0, len);
				}
				char qian = strs[i][len]; // ǰһ������ ��jΪ��ĸ
				char hou = strs[i + 1][len]; // ��һλ���� ��j Ϊ��ĸ
				if (qian != hou)
				{
					// ��һ�����ȵľͿ�����������
					return strs[0].substr(0, len);
				}
			}
			len++;
		}
		return strs[0].substr(0, len);
	}

	bool isExist(vector<int>& v, int value) {
		for (vector<int>::iterator it = v.begin(); it != v.end(); it++)
		{
			if (*it == value)
			{
				return true;
			}
		}
		return false;
	}
	vector<int> findDuplicates(vector<int>& nums) {

		vector<int> result;
		int lowIndex = 0;
		int len = nums.size();
		while (lowIndex < len)
		{
			while (nums[lowIndex] != lowIndex + 1)
			{
				int temp = nums[nums[lowIndex] - 1];
				if (temp == nums[lowIndex])
				{
					if (!isExist(result, temp))
					{
						result.push_back(temp);
					}

					//  lowIndex++;
					break;
				}
				else
				{
					nums[nums[lowIndex] - 1] = nums[lowIndex];
					nums[lowIndex] = temp;

				}
			}
			lowIndex++;
		}
		return result;
	}


	vector<int> diStringMatch(string s) {
		vector<int> arr;
		for (size_t i = 0; i <= s.size(); i++)
		{
			arr.push_back(i);
		}
		vector<int> result;
		int lowIndex = 0;
		int fastIndex = arr.size() - 1;
		while (lowIndex < fastIndex)
		{
			for (size_t i = 0; i < s.size(); i++)
			{
				if (s[i] == 'D')
				{
					result.push_back(arr[fastIndex]);
					fastIndex--;
				}
				else {
					result.push_back(arr[lowIndex]);
					lowIndex++;
				}

			}
		}
		result.push_back(arr[lowIndex]);
		return result;
	}

	void traversal(TreeNode* root, vector<int>& v) {

		if (root == NULL)
		{
			return;
		}
		v.push_back(root->val);
		traversal(root->left, v);
		traversal(root->right, v);

	}

	vector<int> preorderTraversal(TreeNode* root) {
		vector<int> v;
		traversal(root, v);
		return v;
	}

};
class RecentCounter {
public:
	RecentCounter() {

	}
	vector<int> list;
	int ping(int t) {
		int count = 0;

		list.push_back(t);
		int lastIndex = list.size() - 1;
		int value = list[lastIndex];
		while (t - value <= 3000 && lastIndex >= 0)
		{
			count++;
			if (lastIndex == 0)
			{
				return count;
			}
			lastIndex--;
			value = list[lastIndex];

		}

		return count;
	}
};
int main()
{
	Solution so;


	vector<int> arr;

	arr.push_back(4);
	arr.push_back(3);
	arr.push_back(2);
	arr.push_back(7);
	arr.push_back(8);
	arr.push_back(2);
	arr.push_back(3);
	arr.push_back(1);

	so.findDuplicates(arr);
	so.diStringMatch("DIDI");
	//so.sortArrayByParity(arr);
	//so.findTheWinner(5, 2);
	return 0;
}