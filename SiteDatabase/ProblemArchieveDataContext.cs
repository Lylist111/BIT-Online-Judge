namespace BITOJ.Data
{
    using BITOJ.Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// Ϊ����Ŀ���ṩ���������ġ�
    /// </summary>
    public partial class ProblemArchieveDataContext : DbContext
    {
        /// <summary>
        /// ��ʼ�� ProblemArchieveDataContext �����ʵ����
        /// </summary>
        public ProblemArchieveDataContext()
            : base("name=ProblemArchieveDataContext")
        {
        }

        /// <summary>
        /// ����������Ŀʵ�������������ݼ��С�
        /// </summary>
        /// <param name="entity">Ҫ��ӵ���Ŀʵ�����</param>
        /// <exception cref="ArgumentNullException"/>
        public void AddProblemEntity(ProblemEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Problems.Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// ʹ�ø�������Ŀʵ�� ID ��ѯ��Ŀʵ����󲢷��ء�
        /// </summary>
        /// <param name="id">Ҫ��ѯ����Ŀʵ�� ID��</param>
        /// <returns>��Ŀʵ�������û�з���Ҫ�����Ŀʵ����󣬷��� null ��</returns>
        public ProblemEntity GetProblemEntityById(int id)
        {
            return Problems.Find(id);
        }

        /// <summary>
        /// ��ѯ���ݼ��е�������Ŀʵ�����
        /// </summary>
        /// <returns>һ���ɲ�ѯ���󣬸ö���ɲ�ѯ�����ݼ��е�������Ŀʵ�����</returns>
        public IQueryable<ProblemEntity> GetAllProblemEntities()
        {
            return Problems;
        }

        /// <summary>
        /// ʹ�ø�������Ŀ�����ѯ��Ŀʵ����󲢷��ء�
        /// </summary>
        /// <param name="title">Ҫ��ѯ����Ŀ���⡣</param>
        /// <returns>һ���ɲ�ѯ���󣬸ö���ɲ�ѯ�����еķ���Ҫ���ʵ�����</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <remarks>
        /// �ڵ�һ�������汾�У��ݲ�֧��ģ����ѯ����֧����ȫƥ���ѯ��
        /// </remarks>
        public IQueryable<ProblemEntity> QueryProblemEntitiesByTitle(string title)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title));

            var entities = from item in Problems
                           where item.Title == title
                           select item;
            return entities;
        }

        /// <summary>
        /// ʹ�ø�������Ŀ���߲�ѯ��Ŀʵ����󲢷��ء�
        /// </summary>
        /// <param name="author">Ҫ��ѯ�����ߡ�</param>
        /// <returns>һ���ɲ�ѯ���󣬸ö���ɲ�ѯ�����еķ���Ҫ���ʵ�����</returns>
        /// <exception cref="ArgumentNullException"/>
        public IQueryable<ProblemEntity> QueryProblemEntitiesByAuthor(string author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            var entities = from item in Problems
                           where item.Author == author
                           select item;
            return entities;
        }

        /// <summary>
        /// ʹ�ø�������Ŀ��Դ��ѯ��Ŀʵ����󲢷��ء�
        /// </summary>
        /// <param name="source">Ҫ��ѯ����Ŀ��Դ��</param>
        /// <returns>һ���ɲ�ѯ���󣬸ö���ɲ�ѯ�����еķ���Ҫ���ʵ�����</returns>
        /// <exception cref="ArgumentNullException"/>
        public IQueryable<ProblemEntity> QueryProblemEntitiesBySource(string source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var entities = from item in Problems
                           where item.Source == source
                           select item;
            return entities;
        }

        /// <summary>
        /// �����ݼ����Ƴ�������Ŀʵ�����
        /// </summary>
        /// <param name="entity">Ҫ�Ƴ�����Ŀʵ�����</param>
        public void RemoveProblemEntity(ProblemEntity entity)
        {
            Problems.Remove(entity);
        }

        /// <summary>
        /// ��ȡ����������Ŀ����Ŀʵ�����ݼ���
        /// </summary>
        protected DbSet<ProblemEntity> Problems { get; set; }
    }
}
