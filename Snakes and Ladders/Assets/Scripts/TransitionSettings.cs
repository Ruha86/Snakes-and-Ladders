using UnityEngine;

public class TransitionSettings : MonoBehaviour
{
    // ������ � ������� � ������������
    // �������� ��� ����� � ����������
    public TransitionData[] TransitionDatas = new TransitionData[0];

    public int GetTransitionResultCellId(int startCellId)
    {
        // �������� � ����� �� ����� ������� � ������� � ������������ �� ����� � ���������
        for (int i = 0; i < TransitionDatas.Length; i++)
        {
            // �������� ����� ����� ������ �� TransitionData ��� ������� �������� startCellId
            int resultCellId = TransitionDatas[i].GetTransitionResultCellId(startCellId);

            // ���� resultCellId ������ ��� ����� 0
            if (resultCellId >= 0)
            {
                // ������, ����������� ��������
                return resultCellId;
            }
        }
        // ���� ������� �� �����������, ���������� -1 � ��� ������, ��� ����������� �� ���� ��� �������� ��� 
        return -1;
    }
}
