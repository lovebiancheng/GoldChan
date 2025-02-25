function AddListener()
	begainGameButton.onClick:AddListener(OnBegainClick)
    settingButton.onClick:AddListener(OnSettingClick)
    emailButton.onClick:AddListener(OnEmailClick)
    friendButton.onClick:AddListener(OnFriendClick)
end

function Removelistener()
	begianGameButton.onClick:RemoveAllListeners()
	settingButton.onClick:RemoveAllListeners()
	emailButton.onClick:RemoveAllListeners()
	friendButton.onClick:RemoveAllListeners()
end

function OnBegainClick()
	--跳转到游戏界面
	CS.UnityEngine.Debug.Log("打开游戏界面")
	mainUI:ChangeUIState()
end

function OnSettingClick()
	--跳转到设置界面
	CS.UnityEngine.Debug.Log("打开设置界面")
end

function OnEmailClick()
	--跳转到邮件界面
	CS.UnityEngine.Debug.Log("打开邮件界面")
end

function OnFriendClick()
	--跳转到好友界面
	CS.UnityEngine.Debug.Log("打开好友界面")
end

function ChangeRoleImage()
	--更改角色头像
end

function ChangeOutsideImage()
	--更改角色框
end
