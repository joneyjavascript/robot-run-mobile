public interface IDead {
  bool isInvecible { get; }
  bool isDead { get; }

  void Dead(IKill killer);
}