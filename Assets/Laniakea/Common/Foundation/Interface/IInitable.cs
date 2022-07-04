internal interface IInitable
{
    void Init();
    void SetInited();

    bool IsInited();

    public void SafeInit()
    {
        Init();
        SetInited();
    }
}
