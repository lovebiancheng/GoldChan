function AddListener( )
	
	fetterButton.onClick:AddListener(OnFetterClick)
	equipmentButton.onClick:AddListener(OnEquipmentClick)
	buyExperienceButton.onClick:AddListener(OnBuyExperienceClick)
	buyRoleButton.onClick:AddListener(OnBuyRoleClick)
	attackDetialButton.onClick:AddListener(OnAttackDetialClick)
	settingButton.onClick:AddListener(OnSettingClick)
	squadButton.onClick:AddListener(OnSquadClick)
end

function RemoveListener()
	fetterButton.onClick:RemoveAllListeners()
	equipmentButton.onClick:RemoveAllListeners()
	buyExperienceButton.onClick:RemoveAllListeners()
	buyRoleButton.onClick:RemoveAllListeners()
	attackDetialButton.onClick:RemoveAllListeners()
	settingButton.onClick:RemoveAllListeners()
	squadButton.onClick:RemoveAllListeners()
end

function OnFetterClick()
	CS.UnityEngine.Debug.Log("打开Fetter界面")
end

function OnEquipmentClick()
	CS.UnityEngine.Debug.Log("打开Equipment界面")
end

function OnBuyExperienceClick()
	CS.UnityEngine.Debug.Log("打开BuyExperience界面")
end
function OnBuyRoleClick()
	CS.UnityEngine.Debug.Log("打开BuyRole界面")
end
function OnAttackDetialClick()
	CS.UnityEngine.Debug.Log("打开AttackDetial界面")
end
function OnSettingClick()
	CS.UnityEngine.Debug.Log("打开Setting界面")
end
function OnSquadClick()
	CS.UnityEngine.Debug.Log("打开Squad界面")
end