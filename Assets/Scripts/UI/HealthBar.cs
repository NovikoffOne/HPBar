using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    
    private float _speed = 0.5f;
    private float _durationWaitSeconds = 0.01f;
    private WaitForSeconds _waitSeconds;

    private void Start()
    {
        _waitSeconds = new WaitForSeconds(_durationWaitSeconds);
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
        _slider.value = 1;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value, int maxValue)
    {
        float lastValue = _slider.value;
        float currentValue = (float)value / maxValue;

        StartCoroutine(SmutheHealthValue(lastValue, currentValue));
    }

    private IEnumerator SmutheHealthValue(float lastValue, float currentValue)
    {
        while(currentValue != lastValue)
        {
            yield return _waitSeconds;

            _slider.value = Mathf.MoveTowards(lastValue, currentValue, _speed * Time.deltaTime);

            lastValue = _slider.value;
        }
    }
}
