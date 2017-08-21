namespace BITOJ.Data
{
    using BITOJ.Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// Ϊ�û����ݿ������ṩ������֧�֡�
    /// </summary>
    public partial class UserDataContext : DbContext
    {
        /// <summary>
        /// ��ʼ�� UserDataContext �����ʵ����
        /// </summary>
        public UserDataContext()
            : base("name=UserDataContext")
        {
        }

        /// <summary>
        /// ���������û���Ϣʵ��������������ݿ��С�
        /// </summary>
        /// <param name="entity">Ҫ��ӵ��û���Ϣʵ�����ݡ�</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        /// <remarks>
        /// ��������ʵ�������Ѿ����������ݿ��У��׳� InvalidOperationException �쳣��
        /// ��Ҫ���¸�����ʵ�����ݣ���ʹ�� UpdateUserProfileEntity ������
        /// </remarks>
        public void AddUserProfileEntity(UserProfileEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (QueryUserProfileEntity(entity.Username) != null)
                throw new InvalidOperationException("������ʵ������Ѿ����������ݿ��С�");

            UserProfiles.Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// �������Ķ�����Ϣʵ��������������ݿ��С�
        /// </summary>
        /// <param name="entity">Ҫ��ӵĶ�����Ϣʵ�����ݡ�</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        /// <remarks>
        /// ��������ʵ������Ѿ����������ݿ��У��׳� InvalidOperationException �쳣��
        /// ��Ҫ�������ݿ��ж�Ӧ��ʵ�����ݣ������ UpdateTeamProfileEntity ������
        /// </remarks>
        public void AddTeamProfileEntity(TeamProfileEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            TeamProfiles.Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// ���������û� - �����ϵʵ����������ݿ��С�
        /// </summary>
        /// <param name="entity">Ҫ��ӵ��û� - �����ϵʵ�����</param>
        /// <exception cref="ArgumentNullException"/>
        public void AddUserTeamRelationEntity(UserTeamRelationEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            UserTeams.Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// ��ȡ���е��û�������Ϣʵ�����
        /// </summary>
        /// <returns>һ���ɲ�ѯ���󣬰��������е��û�������Ϣʵ�����</returns>
        public IQueryable<UserProfileEntity> GetAllUserProfiles()
        {
            return UserProfiles;
        }

        /// <summary>
        /// ��ȡ���еĶ�����Ϣʵ�����
        /// </summary>
        /// <returns>һ���ɲ�ѯ���󣬰��������е��û�Ȩ����Ϣʵ�����</returns>
        public IQueryable<TeamProfileEntity> GetAllTeamProfiles()
        {
            return TeamProfiles;
        }

        /// <summary>
        /// ��ȡ���е��û� - �����ϵʵ�����
        /// </summary>
        /// <returns>һ���ɲ�ѯ���󣬰��������е��û� - �����ϵʵ�����</returns>
        public IQueryable<UserTeamRelationEntity> GetAllUserTeamRelations()
        {
            return UserTeams;
        }

        /// <summary>
        /// ʹ��ָ�����û�����ѯ�û���Ϣʵ�����
        /// </summary>
        /// <param name="username">Ҫ��ѯ���û�����</param>
        /// <returns>��Ӧ���û���Ϣʵ���������������û���δ�����ݿ����ҵ������� null��</returns>
        /// <exception cref="ArgumentNullException"/>
        public UserProfileEntity QueryUserProfileEntity(string username)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username));

            return UserProfiles.Find(username);
        }

        /// <summary>
        /// ʹ�ø����Ķ��� ID ��ѯ������Ϣʵ�����
        /// </summary>
        /// <param name="teamId">Ҫ��ѯ�Ķ��� ID ��</param>
        /// <returns>����� ID ���Ӧ�Ķ�����Ϣʵ������������Ķ��� ID δ�����ݿ����ҵ������� null ��</returns>
        public TeamProfileEntity QueryTeamProfileEntityById(int teamId)
        {
            return TeamProfiles.Find(teamId);
        }

        /// <summary>
        /// ʹ�ø����Ķ��� ID ��ѯ��������������û� - �����ϵʵ�����
        /// </summary>
        /// <param name="teamId">Ҫ��ѯ�Ķ��� ID ��</param>
        /// <returns>һ���ɲ�ѯ���󣬸ö���ɲ�ѯ����ָ������������������û� - �����ϵʵ�����</returns>
        public IQueryable<UserTeamRelationEntity> QueryUserTeamRelationEntitiesByTeamId(int teamId)
        {
            var entities = from item in UserTeams
                           where item.TeamId == teamId
                           select item;
            return entities;
        }

        /// <summary>
        /// �������ݿ��и������û���Ϣʵ�����ݡ�
        /// </summary>
        /// <param name="entity">Ҫ���µ�ʵ�����ݡ�</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        /// <remarks>
        /// ��������ʵ�����ݲ������ݿ��У��׳� InvalidOperationException �쳣��
        /// ��Ҫ��������ʵ��������������ݿ��У������ AddUserProfileEntity ������
        /// </remarks>
        public void UpdateUserProfileEntity(UserProfileEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            UserProfileEntity target = QueryUserProfileEntity(entity.Username);
            if (target == null)
                throw new InvalidOperationException("�������û���Ϣʵ�����δ�����ݿ����ҵ���");

            // ����ʵ��������ݡ�
            target.ProfileFileName = entity.ProfileFileName;
            SaveChanges();
        }

        /// <summary>
        /// �������ݿ��и����Ķ�����Ϣʵ�����ݡ�
        /// </summary>
        /// <param name="entity">Ҫ���µĶ�����Ϣʵ�����ݡ�</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        /// <remarks>
        /// ��������ʵ�����δ�����ݿ����ҵ����׳� InvalidOperationException �쳣��
        /// ��Ҫ��������ʵ�������������ݿ⣬����� AddTeamProfileEntity ������
        /// </remarks>
        public void UpdateTeamProfileEntity(TeamProfileEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            TeamProfileEntity target = QueryTeamProfileEntityById(entity.Id);
            if (target == null)
                throw new InvalidOperationException("�����Ķ�����Ϣʵ������δ�����ݿ����ҵ���");

            // ����ʵ��������ݡ�
            target.ProfileFile = entity.ProfileFile;
            SaveChanges();
        }

        /// <summary>
        /// �����ݿ���ɾ���������û���Ϣʵ�����ݡ�
        /// </summary>
        /// <param name="entity">Ҫɾ�����û���Ϣʵ�����ݡ�</param>
        /// <exception cref="ArgumentNullException"/>
        public void RemoveUserProfileEntity(UserProfileEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            UserProfiles.Remove(entity);
            SaveChanges();
        }

        /// <summary>
        /// �����ݿ���ɾ�������Ķ�����Ϣʵ�����ݡ�
        /// </summary>
        /// <param name="entity">Ҫɾ���Ķ�����Ϣʵ�����ݡ�</param>
        /// <exception cref="ArgumentNullException"/>
        public void RemoveTeamProfileEntity(TeamProfileEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            TeamProfiles.Remove(entity);
            SaveChanges();
        }

        /// <summary>
        /// �����ݿ���ɾ���������û� - �����ϵʵ�����
        /// </summary>
        /// <param name="entity">Ҫɾ�����û� - �����ϵʵ�����</param>
        /// <exception cref="ArgumentNullException"/>
        public void RemoveUserTeamRelationEntity(UserTeamRelationEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            UserTeams.Remove(entity);
            SaveChanges();
        }

        /// <summary>
        /// ����ָ������֯���ƴӸ���������Դ�в�ѯ������ͬ��֯���Ƶ��û���Ϣʵ�����
        /// </summary>
        /// <param name="source">����Դ��</param>
        /// <param name="organization">��֯���ơ�</param>
        /// <returns>һ���ɲ�ѯ���󣬰��������е������������û���Ϣʵ�����</returns>
        /// <exception cref="ArgumentNullException"/>
        public static IQueryable<UserProfileEntity> QueryUserProfileEntitiesByOrganization(
            IQueryable<UserProfileEntity> source, string organization)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (organization == null)
                throw new ArgumentNullException(nameof(organization));

            var entities = from item in source
                           where item.Organization == organization
                           select item;
            return entities;
        }

        /// <summary>
        /// ����ָ�����û�Ȩ����Ӹ���������Դ�в�ѯ�û���Ϣʵ�����
        /// </summary>
        /// <param name="source">����Դ��</param>
        /// <param name="userGroup">�û�Ȩ���顣</param>
        /// <returns>һ���ɲ�ѯ���󣬰��������е������������û���Ϣʵ�����</returns>
        /// <exception cref="ArgumentNullException"/>
        public static IQueryable<UserProfileEntity> QueryUserProfileEntitiesByUsergroup(
            IQueryable<UserProfileEntity> source, UserGroup userGroup)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var entities = from item in source
                           where item.UserGroup == userGroup
                           select item;
            return entities;
        }

        /// <summary>
        /// ʹ�ø����Ķ������ƴӸ���������Դ�в�ѯ������Ϣʵ�����ݡ�
        /// </summary>
        /// <param name="source">����Դ��</param>
        /// <param name="teamName">Ҫ��ѯ�Ķ������ơ�</param>
        /// <returns>
        /// һ���ɲ�ѯ���󣬸ö���ɲ�ѯ������������������Ӧ�Ķ�����Ϣʵ�����
        /// </returns>
        /// <exception cref="ArgumentNullException"/>
        public static IQueryable<TeamProfileEntity> QueryTeamProfileEntityByName(IQueryable<TeamProfileEntity> source,
            string teamName)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (teamName == null)
                throw new ArgumentNullException(nameof(teamName));

            var entities = from item in source
                           where item.Name == teamName
                           select item;
            return entities;
        } 

        /// <summary>
        /// ʹ�ø������û����Ӹ���������Դ�в�ѯָ���û��������û� - �����ϵʵ�����
        /// </summary>
        /// <param name="source">����Դ��</param>
        /// <param name="username">Ҫ��ѯ���û�����</param>
        /// <returns>һ���ɲ�ѯ���󣬸ö���ɲ�ѯ����ָ���û�������������û� - �����ϵʵ�����</returns>
        /// <exception cref="ArgumentNullException"/>
        public static IQueryable<UserTeamRelationEntity> QueryUserTeamRelationEntitiesByUsername(
            IQueryable<UserTeamRelationEntity> source, string username)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (username == null)
                throw new ArgumentNullException(nameof(username));

            var entities = from item in source
                           where item.Username == username
                           select item;
            return entities;
        }

        /// <summary>
        /// ��ȡ�������û���Ϣ���ݼ���
        /// </summary>
        protected virtual DbSet<UserProfileEntity> UserProfiles { get; set; }

        /// <summary>
        /// ��ȡ�����ö�����Ϣ���ݼ���
        /// </summary>
        protected virtual DbSet<TeamProfileEntity> TeamProfiles { get; set; }

        /// <summary>
        /// ��ȡ�������û� - �����ϵ���ݼ���
        /// </summary>
        protected virtual DbSet<UserTeamRelationEntity> UserTeams { get; set; }
    }
}
