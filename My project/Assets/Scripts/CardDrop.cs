using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDrop : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    private Image image;
    private RectTransform rect;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    // ���콺 �����Ͱ� ���� ������ ���� ���� ���η� �� �� 1ȸ ȣ��
    public void OnPointerEnter(PointerEventData eventData)
    {
        // ������ ������ ������ ��������� ����
        image.color = Color.yellow;
    }



    // ���콺 �����Ͱ� ���� ������ ���� ������ �������� �� 1ȸ ȣ��
    public void OnPointerExit(PointerEventData eventData)
    {
        // ������ ������ ������ �Ͼ������ ����
        image.color = Color.white;
    }



    // ���� ������ ���� ���� ���ο��� ����� ���� �� 1ȸ ȣ��
    public void OnDrop(PointerEventData eventData)
    {
        // pointerDrag�� ���� �巡���ϰ� �ִ� ���(=������)
        if ( eventData.pointerDrag != null)
        {
            // �巡���ϰ� �ִ� ����� �θ� ���� ������Ʈ�� �����ϰ�, ��ġ�� ���� ������Ʈ ��ġ�� �����ϰ� ����
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        }
    }
}
