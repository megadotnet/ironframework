# 核心流程: 员工生命周期管理 (Employee Lifecycle)

## 1. 业务流程总览

本模块详细阐述了员工从"入职录入"到"信息变更"的全生命周期管理。

### 1.1 入职流程 (Onboarding Process)
这是业务的起点，确保新员工的基础数据准确无误地进入系统。

```mermaid
flowchart TD
    Start[开始: HR 发起入职申请] --> Input[步骤 1: 填写基础信息]
    Input --> InfoDetail[包含: 登录名/职位/身份证号/性别/婚姻状况]

    InfoDetail --> Validate{步骤 2: 数据完整性校验}

    Validate -- 校验不通过 --> ErrorShow[提示错误: 必填项缺失或格式有误]
    ErrorShow --> Input

    Validate -- 校验通过 --> CheckDup{步骤 3: 唯一性检查}

    CheckDup -- 身份证号重复 --> DupError[错误: 该员工档案已存在]
    CheckDup -- 登录名重复 --> LoginError[错误: 登录名已被占用]

    DupError --> Input
    LoginError --> Input

    CheckDup -- 通过 --> SaveData[步骤 4: 系统写入数据]
    SaveData --> Success[结束: 员工档案创建成功]

    style Start fill:#ccffcc,stroke:#006600,stroke-width:2px
    style Success fill:#ccffcc,stroke:#006600,stroke-width:2px
    style ErrorShow fill:#ffcccc,stroke:#cc0000,stroke-width:1px
    style DupError fill:#ffcccc,stroke:#cc0000,stroke-width:1px
    style LoginError fill:#ffcccc,stroke:#cc0000,stroke-width:1px
```

---

## 2. 员工信息变更流程 (Update Process)

随着员工在企业内的发展，其信息会不断发生变化（如晋升、婚姻状况变更等）。

### 2.1 变更操作逻辑

```mermaid
sequenceDiagram
    participant HR as HR 管理员
    participant UI as 前端界面
    participant Sys as 业务系统
    participant DB as 数据库

    HR->>UI: 1. 检索并选中目标员工
    UI->>Sys: 请求员工详情 [ID: 10086]
    Sys->>DB: 读取最新档案
    DB-->>Sys: 返回员工数据
    Sys-->>UI: 展示详情页

    HR->>UI: 2. 修改信息 [如: 职位从 '销售' 改为 '销售经理']
    UI->>Sys: 提交变更请求

    rect rgb(240, 248, 255)
        note right of Sys: 系统内部处理
        Sys->>Sys: 校验新数据的合法性
        Sys->>DB: 执行更新操作
    end

    alt 更新成功
        DB-->>Sys: 确认受影响行数
        Sys-->>UI: 返回成功状态
        UI-->>HR: 提示 "保存成功"
    else 更新失败
        DB-->>Sys: 抛出异常 [如: 数据库连接超时]
        Sys-->>UI: 返回错误代码
        UI-->>HR: 提示 "系统繁忙，请重试"
    end
```

---

## 3. 员工状态模型 (Logical State Machine)

虽然底层数据库可能没有显式的 "状态字段"，但在业务逻辑层面，员工档案存在以下几种逻辑状态：

```mermaid
stateDiagram-v2
    [*] --> New : HR 录入信息

    New --> Active : 校验通过并保存
    note right of Active : 正常在职状态

    Active --> Modified : 信息变更 [职位/婚姻状况]
    Modified --> Active : 变更生效

    Active --> PayAdjusted : 薪资调整
    PayAdjusted --> Active : 调整生效

    Active --> Inactive : 离职/归档 [逻辑删除]
    Inactive --> [*]
```

### 3.1 状态说明
*   **New (新建)**: 临时状态，指数据正在录入但尚未持久化。
*   **Active (在职/有效)**: 系统的主要稳态，员工可以被搜索、被查询。
*   **Modified (变更中)**: 当 HR 点击"编辑"但未保存时，系统需锁定或标记该状态以防冲突（取决于并发策略）。
*   **PayAdjusted (调薪)**: 触发了 `EmployeePayHistory` 的变更，属于特殊的子状态。
*   **Inactive (归档)**: 员工离职后，数据不物理删除，而是标记为无效，保留历史供查。
