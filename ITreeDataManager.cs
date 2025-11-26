namespace Proyecto.FamilyTreeSpace
{
    public interface ITreeDataManager
    {
        void SaveTree(FamilyTree tree, string filePath);
        FamilyTree LoadTree(string filePath);
        void ExportToJson(FamilyTree tree, string filePath);
    }
}
