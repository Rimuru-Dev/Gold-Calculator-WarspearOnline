using UnityEngine;
using TMPro;

public sealed class Test : MonoBehaviour
{
    public TMP_InputField newCource;
    public TMP_InputField inputColdcount;
    public TMP_InputField inputRubcount;

    public TMP_Text courceText;

    public float defaultCourceRub = 1.7f;
    public float defaultCourceGold = 1000f;

    public float courceRub;
    public float courceGold;

    public float gold;
    public float rub;
    public float cource;

    private void Start()
    {
        courceRub = defaultCourceRub;
    }

    public void OpenAndClosePanel(GameObject panel) =>
        panel.SetActive(!panel.activeInHierarchy);

    private void Update()
    {
        courceText.text = $"   урс: [{defaultCourceGold}] к [{courceRub} руб] ";
    }

    public void WriteNewCource() => courceRub = GetNewExchangeRate();

    private float GetNewExchangeRate() => float.Parse(newCource.text);
}