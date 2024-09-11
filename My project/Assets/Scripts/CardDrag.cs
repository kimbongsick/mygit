using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;           // UI�� �ҼӵǾ� �ִ� �ֻ���� Canvas Transform
    private Transform previousParent;   // �ش� ������Ʈ�� ������ �ҼӵǾ� �־��� �κ� Transform
    private RectTransform rect;         // UI ��ġ ��� ���� RectTrnasform
    private CanvasGroup canvasGroup;    // UI�� ���İ��� ��ȣ�ۿ� ��� ���� CanvasGroup

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }



    // ���� ������Ʈ�� �巡���ϱ� ������ �� 1ȸ ȣ��
    public void OnBeginDrag(PointerEventData eventData)
    {
        // �巡�� ������ �ҼӵǾ� �ִ� �θ� Transform ���� ����
        previousParent = transform.parent;

        // ���� �巡������ UI�� ȭ���� �ֻ�ܿ� ��µǷ� �ϱ� ����
        transform.SetParent(canvas);        // �θ� ������Ʈ�� Canvas�� ����
        transform.SetAsLastSibling();       // ���� �տ� ���̵��� ������ �ڽ����� ����

        // �巡�� ������ ������Ʈ�� �ϳ��� �ƴ� �ڽĵ��� ������ ���� �����ֱ� ������ CanvasGroup���� ����
        // ���İ��� 0.6���� �����ϰ�, ���� �浹ó���� ���� �ʵ��� �Ѵ�
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    

    // ���� ������Ʈ�� �巡�� ���� �� �� ������ ȣ��
    public void OnDrag(PointerEventData eventData)
    {
        // ���� ��ũ������ ���콺 ��ġ�� UI ��ġ�� ���� (UI�� ���콺�� �Ѿƴٴϴ� ����)
        rect.position = eventData.position;
    }




    // ���� ������Ʈ�� �巡�׸� ������ �� 1ȸ ȣ��
    public void OnEndDrag(PointerEventData eventData)
    {
        // �巡�׸� �����ϸ� �θ� canvas�� �����Ǳ� ������
        // �巡�׸� ������ �� �θ� canvas�̸� ������ ������ �ƴ� ������ ����
        // ����� �ߴٴ� ���̱� ������ �巡�� ������ �ҼӵǾ� �ִ� ������ �������� ������ �̵�
        if ( transform.parent == canvas )
        {
            // �������� �ҼӵǾ��־��� previousParent�� �ڽ����� �����ϰ�, �ش� ��ġ�� ����
            transform.SetParent (previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
        }

        // ���İ��� 1�� �����ϰ�, ���� �浹ó���� �ǵ��� �Ѵ�
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }

}
