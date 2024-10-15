using System.Collections;
using UnityEngine;
using TextField = TMPro.TMP_Text;

[RequireComponent(typeof(TextField))]
public class FrameRateDIsplayer : MonoBehaviour
{
    [SerializeField] private TextField _textField;

    void Start()
    {
        if (_textField == null) _textField = GetComponent<TextField>();
        StartTimer();
    }

    private IEnumerator SetFrameRate()
    {
        float t = 0;
        int count = 0;
        while (t < 1f)
        {
            t += Time.deltaTime;
            count++;
            yield return null;
        }
        _textField.text = count.ToString();
        StartTimer();
    }

    private void StartTimer() => StartCoroutine(SetFrameRate());
}
