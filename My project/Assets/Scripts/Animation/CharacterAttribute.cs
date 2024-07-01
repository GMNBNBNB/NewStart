[System.Serializable]

public struct CharacterAttribute
{
    public CharacterPartAnimator characterPart;
    public PartVariantColor partVariantColour;
    public PartVariantType partVariantType;

    public CharacterAttribute(CharacterPartAnimator characterPart, PartVariantColor partVariantColour, PartVariantType partVariantType)
    {
        this.characterPart = characterPart;
        this.partVariantColour = partVariantColour;
        this.partVariantType = partVariantType;
    }
}