namespace BITOJ.Data
{
    using BITOJ.Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// Ϊ���������ṩ������֧�֡�
    /// </summary>
    public partial class ContestDataContext : DbContext
    {
        /// <summary>
        /// ��ʼ�� ContestDataContext �����ʵ����
        /// </summary>
        public ContestDataContext()
            : base("name=ContestDataContext")
        {
        }

        /// <summary>
        /// �������ı���ʵ��������������ݿ��С�
        /// </summary>
        /// <param name="entity">Ҫ��ӵı���ʵ�塣</param>
        /// <exception cref="ArgumentNullException"/>
        public void AddContest(ContestEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Contests.Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// ������ ID ��ѯ����ʵ�����
        /// </summary>
        /// <param name="contestId">Ҫ��ѯ�ı��� ID ��</param>
        /// <returns>
        /// ���и������� ID ֵ�ñ���ʵ�������δ�����ݿ����ҵ���Ӧ�ı���ʵ����󣬷��� null ��
        /// </returns>
        public ContestEntity QueryContestById(int contestId)
        {
            return Contests.Find(contestId);
        }

        /// <summary>
        /// �������ѯ����ʵ�����
        /// </summary>
        /// <param name="title">Ҫ��ѯ�ı��⡣</param>
        /// <returns>һ���ɲ�ѯ���󣬸ö�����������б���Ϊ����ֵ�ı���ʵ�����</returns>
        /// <exception cref="ArgumentNullException"/>
        public IQueryable<ContestEntity> QueryContestsByTitle(string title)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title));

            var entities = from item in Contests
                           where item.Title == title
                           select item;
            return entities;
        }

        /// <summary>
        /// �����߲�ѯ����ʵ�����
        /// </summary>
        /// <param name="creator">Ҫ��ѯ�����ߵ��û�����</param>
        /// <returns>һ���ɲ�ѯ���󣬸ö����������������Ϊ����ֵ�ı���ʵ�����</returns>
        /// <exception cref="ArgumentNullException"/>
        public IQueryable<ContestEntity> QueryContestsByCreator(string creator)
        {
            if (creator == null)
                throw new ArgumentNullException(nameof(creator));

            var entities = from item in Contests
                           where item.Creator == creator
                           select item;
            return entities;
        }

        /// <summary>
        /// ��ѯ����δ��ʼ�ı���ʵ�����
        /// </summary>
        /// <returns>һ���ɲ�ѯ���󣬸ö���ɲ�ѯ�����е�δ��ʼ�ı���ʵ�����</returns>
        public IQueryable<ContestEntity> QueryUnstartedContests()
        {
            DateTime now = DateTime.Now;
            var entities = from item in Contests
                           where item.StartTime > now
                           select item;
            return entities;
        }

        /// <summary>
        /// ��ѯ�������ڽ��еı���ʵ�����
        /// </summary>
        /// <returns>һ���ɲ�ѯ���󣬸ö���ɲ�ѯ�����е����ڽ��еı���ʵ�����</returns>
        public IQueryable<ContestEntity> QueryRunningContests()
        {
            DateTime now = DateTime.Now;
            var entities = from item in Contests
                           where item.StartTime <= now && item.EndTime >= now
                           select item;
            return entities;
        }

        /// <summary>
        /// ��ѯ�����ѽ����ı���ʵ�����
        /// </summary>
        /// <returns>һ���ɲ�ѯ���󣬸ö���ɲ�ѯ�����е��ѽ����ı���ʵ�����</returns>
        public IQueryable<ContestEntity> QueryEndedContests()
        {
            DateTime now = DateTime.Now;
            var entities = from item in Contests
                           where item.EndTime < now
                           select item;
            return entities;
        }

        /// <summary>
        /// �����ݿ����Ƴ������ı�������ʵ�塣
        /// </summary>
        /// <param name="entity">Ҫ�Ƴ��ı���ʵ�����</param>
        /// <exception cref="ArgumentNullException"/>
        public void RemoveContest(ContestEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Contests.Remove(entity);
        }

        /// <summary>
        /// ��ȡ�����ñ������ݼ���
        /// </summary>
        protected virtual DbSet<ContestEntity> Contests { get; set; }
    }
}
